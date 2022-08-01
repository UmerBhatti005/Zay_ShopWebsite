import { Component, OnInit } from '@angular/core';
import { NonVolatileService } from './Services/non-volatile.service';
import { BehaviorSubject, Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'ZayShop';

  userSubject: any;
  data: any;

  constructor(private nonVolatile: NonVolatileService){

    this.userSubject = nonVolatile.GetDataToLocalStorage();
this.data = this.userSubject?.tokenOptions?.length;
    console.log(this.data);
    
   }

  ngOnInit(): void {
  }
}
