import { Injectable } from '@angular/core';
import { BehaviorSubject, Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SharedDataService {

  name: any;

  private messageSource = new Subject<any>();
  currentMessage = this.messageSource.asObservable();
  // FastLoadingObj: [];
  constructor() { }

  changeMessage(message: any) {
    debugger;
    this.messageSource.next(message);
    // this.FastLoadingObj = message;
    // console.log(this.FastLoadingObj);
  }
}
