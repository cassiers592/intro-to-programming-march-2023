import { Component } from '@angular/core';

@Component({
  selector: 'app-counter',
  templateUrl: './counter.component.html',
  styleUrls: ['./counter.component.css'],
})
export class CounterComponent {
  // TODO: make this an observable of some data in the store
  current = 0;

  increment() {
    // TODO: dispatch an action to the store to say that the count was incremented
    this.current += 1;
  }

  decrement() {
    // TODO: dispatch an action to the store to say that the count was decremented
    this.current -= 1;
  }
}
