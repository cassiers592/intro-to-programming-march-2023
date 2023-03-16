import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ItemEntityRequestModel } from '../../models/items.models';

@Component({
  selector: 'app-new',
  templateUrl: './new.component.html',
  styleUrls: ['./new.component.css'],
})
export class NewComponent {
  form = new FormGroup<FormDataType<ItemEntityRequestModel>>({
    name: new FormControl<string>('', {
      nonNullable: true,
      validators: [
        Validators.required,
        Validators.maxLength(50),
      ],
    }),
    description: new FormControl<string>('', {
      nonNullable: true,
      validators: [Validators.maxLength(100)],
    }),
    link: new FormControl<string>('', {
      nonNullable: true,
      validators: [
        Validators.required,
      ],
    }),
  });

  get name() {
    return this.form.controls.name;
  }
  get description() {
    return this.form.controls.description;
  }
  get link() {
    return this.form.controls.link;
  }

  addIt() {
    // if the form is valid, dispatch an action
    if (this.form.valid) {
      // TODO: Dispatch an Action
    } else {
      // TODO:
    }
  }
}

type FormDataType<T> = {
  [Property in keyof T]: FormControl<T[Property]>;
};
