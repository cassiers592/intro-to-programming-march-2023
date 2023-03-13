import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';

@Component({
  selector: 'app-support',
  templateUrl: './support.component.html',
  styleUrls: ['./support.component.css']
})
export class SupportComponent {
  // client:HttpClient;

  // constructor(client:HttpClient) {
  //   this.client = client;
  // }

  // OR Equivalently:

  constructor(client:HttpClient) {
    client.get('http://localhost:1338/oncalldeveloper').subscribe(response => console.log('Got the response', response));
  }
}
