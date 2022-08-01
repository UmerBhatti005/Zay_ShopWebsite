import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { CartSystem } from '../Model/CartSystem';
import { CartSystemService } from '../Services/cart-system.service';
import { NonVolatileService } from '../Services/non-volatile.service';
import { NotificationService } from '../Services/notification.service';

@Component({
  selector: 'app-cart-system',
  templateUrl: './cart-system.component.html',
  styleUrls: ['./cart-system.component.css']
})
export class CartSystemComponent implements OnInit {

  cartData: CartSystem[] = [];
  // latestCartData: string;
  username: string;
  UpdatedCartSystem: CartSystem = new CartSystem();
  DeliveredCart: any;

  constructor(private CartSys: CartSystemService,
    private nonVolatile: NonVolatileService,
    private notificationService: NotificationService,
    private spinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    this.GetUser();
    this.GetCartSystemBySpecificUser();

  }

  GetCartSystemBySpecificUser() {
    this.spinnerService.show();
    this.CartSys.GetCartSystemByUsername(this.username).subscribe({
      next: (data) => {
        this.cartData = data;
        console.log(data.length);
        this.spinnerService.hide();
      }
    });
  }

  GetUser() {
    this.username = this.nonVolatile.GetDataToLocalStorage().username;
    console.log(this.username);

  }

  DeleteCartSystem(id: number) {
    this.CartSys.DeleteCartSystem(id).subscribe({
      next: (data) => {
        this.notificationService.showInfo("Cart has been deleted successfully", "Delete Sucessfully");
        this.GetCartSystemBySpecificUser();
      }, error: (e: HttpErrorResponse) => {
        this.notificationService.showError(e.message, e.status.toString())
      }
    })
  }

  Delete(id: number) {
    this.DeleteCartSystem(id);
  }

  UpdateCartSystem() {

    this.cartData.forEach((element: CartSystem) => {
      debugger;
      this.UpdatedCartSystem.id = element.id;
      this.UpdatedCartSystem.name = element.name;
      this.UpdatedCartSystem.price = element.price;
      this.UpdatedCartSystem.image = element.image;
      this.UpdatedCartSystem.quantity = element.quantity
      this.UpdatedCartSystem.colors.id = element.colors.id;
      this.UpdatedCartSystem.productSize.id = element.productSize.id;
      this.UpdatedCartSystem.report.id = 2
      this.UpdatedCartSystem.username = element.username;
      this.CartSys.PutCartSystem(this.UpdatedCartSystem).subscribe({
        next: (data) => {
          console.log(data);
          element = data;
          this.notificationService.showSuccess("Product is deliver in 2 to 3 days", "Cash On Delivery");
        }
      })
    });

  }

}
