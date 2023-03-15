import { Injectable } from '@angular/core';
import { Actions, concatLatestFrom, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { map, tap, filter, catchError, of } from 'rxjs';
import { selectCounterBranch } from '..';
import {
  counterCommands,
  counterDocuments,
  counterEvents,
} from '../actions/counter.actions';
import { CounterState } from '../reducers/counter.reducer';
import { z } from 'zod';

@Injectable()
export class CounterEffects {
  private readonly CountDataSchema = z.object({
    current: z.number(),
    by: z.union([
      z.literal(1),
      z.literal(3),
      z.literal(5),
    ]),
  });

  // logItAll$ = createEffect(
  //   () => {
  //     return this.actions$.pipe(tap((action) => console.log(action.type))); // =>
  //   },
  //   { dispatch: false },
  // );

  // When we are TOLD to load the counter state, check localstorage, if it's there dispatch a document with that data,
  // if it isn't, do nothing
  loadCounterState$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(counterCommands.loadCounterState),
      map(() => localStorage.getItem('counter-state')), // string or null
      filter((storedValue) => storedValue !== null), // stop here if it's null
      map((theString) => JSON.parse(theString!)), // ! tells the compiler that theString is not null
      map((susObject) => this.CountDataSchema.parse(susObject) as CounterState),
      map((counterState) =>
        counterDocuments.counterState({ payload: counterState }),
      ),
      catchError(() => {
        console.log('We have ourselves a hacker here!');
        localStorage.clear();
        return of({ type: 'Localstorage Error' });
      }),
    );
  });

  // Every time an action of type increment, decrement, reset, countBySet happens ...
  // write the counter state to localstorage
  writeCounterState$ = createEffect(
    () => {
      return this.actions$.pipe(
        ofType(
          counterEvents.countBySet,
          counterEvents.incrementButtonClicked,
          counterEvents.decrementButtonClicked,
          counterEvents.resetButtonClicked,
        ),
        concatLatestFrom(() => this.store.select(selectCounterBranch)),
        tap(
          ([
            ,
            data,
          ]) => localStorage.setItem('counter-state', JSON.stringify(data)),
        ),
      );
    },
    { dispatch: false },
  );

  constructor(
    private readonly actions$: Actions,
    private readonly store: Store,
  ) {}
}
