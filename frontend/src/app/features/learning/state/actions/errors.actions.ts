import { createActionGroup, emptyProps, props } from '@ngrx/store';

export const errorsEvents = createActionGroup({
  source: '[Learning] Errors Events',
  events: {
    'Error Happened': props<{ message: string }>(),
    'Clear Error Clicked': emptyProps(),
  },
});
