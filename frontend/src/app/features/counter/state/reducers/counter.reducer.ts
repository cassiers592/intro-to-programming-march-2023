import { createReducer, on } from '@ngrx/store';
import { ValidCountByValues } from '../../models';
import { counterDocuments, counterEvents } from '../actions/counter.actions';

// Describe it for TS
export interface CounterState {
  current: number;
  by: ValidCountByValues;
}

// What is the initial state when application starts
const initialState: CounterState = {
  current: 0,
  by: 1,
};

// here is where we decide that if an action happens, does that mean a new state needs created
// we will have access to the current state and the action that just happened and we use that (if we want) to create a new state
export const reducer = createReducer(
  initialState,
  on(counterDocuments.counterState, (_, a) => a.payload),
  on(counterEvents.incrementButtonClicked, (currentState: CounterState) => ({
    ...currentState,
    current: currentState.current + currentState.by,
  })),
  on(counterEvents.decrementButtonClicked, (s) => ({
    ...s,
    current: s.current - s.by,
  })),
  on(counterEvents.resetButtonClicked, () => initialState),
  on(counterEvents.countBySet, (s, a) => ({ ...s, by: a.by })),
);
