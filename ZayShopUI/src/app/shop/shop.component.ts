import { Component, OnInit } from '@angular/core';
import { Product } from '../Model/Product';
import { ProductService } from '../Services/product.service';
import { NgxSpinnerService } from "ngx-spinner";  
import { NonVolatileService } from '../Services/non-volatile.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})
export class ShopComponent implements OnInit {

  products: Product[] = [];
  product = new Product();
  loading: boolean = false;
  role: any;

  constructor(private productService: ProductService,
    private SpinnerService: NgxSpinnerService,
    private nonVolatile: NonVolatileService) { }

  ngOnInit(): void {
    this.GetProduct();
    this.GetUserRole();
  }
  
  GetProduct() {
    // this.loading = true;
    this.SpinnerService.show();  
    this.productService.GetProduct()
    .subscribe({
      next: (data) => {
          console.log(data);
          this.products = data;
          console.log(this.products);
          this.loading = false;
          this.SpinnerService.hide();  
        }, error: (e) => {
          alert('An Unexpected Error Occured.');
        }
      });

  }

  PostProduct() {
    this.productService.PostProduct(this.product)
      .subscribe({
        next: (data) => {
          console.log(data);
          this.GetProduct();
        }, error: (e) => {
          alert('An Unexpected Error Occured.');
        }
      });
  }

  GetUserRole(){
    this.role = this.nonVolatile.GetDataToLocalStorage().role;
    console.log(this.role);
  }
}
