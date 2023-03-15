import { EntityState, createEntityAdapter } from '@ngrx/entity';
import { createReducer, Action, on } from '@ngrx/store';

export interface ItemEntity {
  id: string;
  name: string;
  description: string;
  link: string;
}

export type ItemsState = EntityState<ItemEntity>;

export const adapter = createEntityAdapter<ItemEntity>();

const initialState = adapter.getInitialState();

export const reducer = createReducer(initialState);
