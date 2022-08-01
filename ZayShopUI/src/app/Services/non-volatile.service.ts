import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NonVolatileService {

  userSubject: any;
  user: any;

  constructor() {
    this.userSubject = new BehaviorSubject<any>(JSON.parse(localStorage.getItem('product-id') || '{}'));
    this.user = this.userSubject.asObservable();
    console.log(this.user);
    console.log(this.userSubject);

  }

  public get userValue(): any {
    return this.userSubject.value;
  }



  SetDataToLocalStorage(data: any) {
    localStorage.setItem('product-id', JSON.stringify(data));
  }

  GetDataToLocalStorage() {
    return JSON.parse(localStorage.getItem("product-id") || '{}');
  }

  clearLocalStorage(){
    localStorage.clear();
  }

}
