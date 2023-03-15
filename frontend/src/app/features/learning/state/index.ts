import { ActionReducerMap, createFeatureSelector } from '@ngrx/store';
import * as fromItems from './reducers/items.reducer';

export const featureName = 'learningFeature';

export interface LearningState {
  items: fromItems.ItemsState;
}

export const reducers: ActionReducerMap<LearningState> = {
  items: fromItems.reducer,
};

const selectFeature = createFeatureSelector<LearningState>(featureName);
