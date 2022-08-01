import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { MdbModalService } from 'mdb-angular-ui-kit/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ModalfrAddComponent } from '../modalfr-add/modalfr-add.component';
import { Product } from '../Model/Product';
import { User } from '../Model/SignUpUser';
import { AccountService } from '../Services/account.service';
import { NonVolatileService } from '../Services/non-volatile.service';
import { NotificationService } from '../Services/notification.service';
import { ProductService } from '../Services/product.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {

  // product:Product[];
  user: User = new User();
  object: any;
  username: string;
  specUser: Product[] = [];

  // constructor(private modalService: NgbModal) { }
  constructor(private modalService: MdbModalService,
    private nonVolatile: NonVolatileService,
    private router: Router,
    private accountService: AccountService,
    private productService: ProductService,
    private notificationService: NotificationService) { }

  role: any;
  ngOnInit(): void {
    this.getCurrentUser();
    this.GetUser();
    this.GetSpecificAdvFromUser();
    this.GetUserRole();
  }

  open() {
    this.modalService.open(ModalfrAddComponent, {
      modalClass: 'modal-lg'
    })
  }
  // Logout the user
  logout() {
    this.nonVolatile.clearLocalStorage();
    this.router.navigate(['/users/login']);
  }

  // get Current User
  getCurrentUser() {
    this.object = this.nonVolatile.GetDataToLocalStorage();
    console.log(this.object);
    this.username = this.object.username;
    console.log(this.username);
  }

  // get User By Username
  GetUser() {
    this.accountService.GetUserByUsername(this.username).subscribe({
      next: (data) => {
        console.log("User =" + data);
        this.user = data
      }
    })
  }

  // get Advertisement from Specific User

  GetSpecificAdvFromUser() {
    this.productService.GetSpecificAdvFromUser(this.username).subscribe({
      next: (data) => {
        console.log(data);
        this.specUser = data;
        console.log(this.specUser);
        console.log(this.specUser[0]?.productImages[0]?.rank);
      }, error: (error : HttpErrorResponse) => {
        this.notificationService.showError(error.message ,error.name);
      }
    })
  }
  GetUserRole() {
    this.role = this.nonVolatile.GetDataToLocalStorage().role;
    console.log(this.role);
  }

}
