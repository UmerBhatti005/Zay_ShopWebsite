import { Component, OnInit } from '@angular/core';
import { Product } from '../Model/Product';
import { NonVolatileService } from '../Services/non-volatile.service';
import { NotificationService } from '../Services/notification.service';
import { ProductService } from '../Services/product.service';
import { SharedDataService } from '../Services/shared-data.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  featurProd: Product[] = [];

  constructor(private productService: ProductService,
    private notificationService: NotificationService,
    private sharedData: SharedDataService,
    private nonVolatile: NonVolatileService) { }

  ngOnInit(): void {
    this.GetFeaturedProduct();
    this.DelL_SAfterOneDay();
  }

  // DelLocalhost(){
  //   this.sharedData.currentMessage.subscribe({
  //     next: (data) => {
  //       console.log(data);

  //     }
  //   })
  // }
  DelL_SAfterOneDay() {
    debugger
    var hours = 23; // to clear the localStorage after 1 hour
    // (if someone want to clear after 8hrs simply change hours=8)
    var now = new Date().getMilliseconds();
    var a = new Date().getTime();
    console.log(a);

    var setupTime = this.nonVolatile.GetDataToLocalStorage().setupTime;
    console.log(setupTime);
    
    if (now - setupTime > hours * 60 * 60 * 1000) {
      debugger;
    // if (now > setupTime) {
      console.log("Completed One day, login again!!");

      this.nonVolatile.clearLocalStorage();
    }
  }

  GetFeaturedProduct() {
    this.productService.GetFeaturedProduct().subscribe({
      next: (data) => {
        console.log(data);
        this.featurProd = data;
      }, error: (error: Response) => {
        this.notificationService.showError(error?.text?.toString(), error?.text?.name);
      }
    })
  }

}
