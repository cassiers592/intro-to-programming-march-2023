import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { catchError, map, mergeMap, of, switchMap } from 'rxjs';
import { errorsEvents } from '../actions/errors.actions';
import {
  itemEvents,
  itemsCommands,
  itemsDocuments,
} from '../actions/items.actions';
import { ItemEntity } from '../reducers/items.reducer';

@Injectable()
export class ItemsEffects {
  // TODO:
  // add the new item
  // send that payload on the action to the API using a POST
  // when it comes to the API, turn it into a itemsDocument.item and send it to the reducers

  additem$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(itemEvents.itemCreationRequested),
      mergeMap(
        // track all the pending requests, merge them together into this code when you respond
        // this (mergeMap ) is usually good for "non safe" operations (methods other than GET)
        (a) =>
          this.client
            .post<ItemEntity>(
              'https://localhost:1340/learning-resources',
              a.payload,
            )
            .pipe(
              map((response) => itemsDocuments.item({ payload: response })),
              catchError(() =>
                of(errorsEvents.errorHappened({ message: 'That failed' })),
              ),
            ),
      ),
    );
  });

  loadItems$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(itemsCommands.loadTheItems),
      switchMap(() =>
        // doesn't track previous requests - the last request is the one that will be handled
        // not only doesn't track the earlier requests, it cancels them
        // usually good for GET requests
        this.client
          .get<{ data: ItemEntity[] }>(
            'http://localhost:1340/learning-resources',
          )
          .pipe(
            map((response) => response.data),
            map((payload) => itemsDocuments.items({ payload })),
          ),
      ),
    );
  });
  constructor(private actions$: Actions, private client: HttpClient) {}
}
