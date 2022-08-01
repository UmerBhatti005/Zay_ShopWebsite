import { Component, OnInit } from '@angular/core';
import { MdbModalService } from 'mdb-angular-ui-kit/modal';
import { Subscription } from 'rxjs';
import { ModalComponent } from '../modal/modal.component';
import { NonVolatileService } from '../Services/non-volatile.service';
import { SharedDataService } from '../Services/shared-data.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  username: string;
  // userCart: CartSystem[] = [];
  subscription: Subscription;
  Countthings: any;
  role: any;
  constructor(private modalService: MdbModalService,
    private nonVolatile: NonVolatileService,
    private sharedData: SharedDataService) { }


  ngOnInit(): void {
    this.GetUser();
    this.CartLength();
  }

  CartLength() {
    debugger;
    this.sharedData.currentMessage.subscribe({
      next: (data) => {
        debugger;
        console.log(data);
        this.Countthings = data;
      }
    })
  }

  open() {
    this.modalService.open(ModalComponent, {
      modalClass: 'modal-fullscreen'
    });
  }

  IsLoggedIn() {
    var data = this.nonVolatile.GetDataToLocalStorage();
    if (data.tokenOptions != null) {
      return true;
    }
    else {
      return false;
    }
  }
  GetUser() {
    this.username = this.nonVolatile.GetDataToLocalStorage().username;
    this.role = this.nonVolatile.GetDataToLocalStorage().role;
    console.log(this.role);

  }

}
