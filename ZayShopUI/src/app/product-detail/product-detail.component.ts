import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { CartSystem } from '../Model/CartSystem';
import { RatingModalComponent } from '../rating-modal/rating-modal.component';
import { CartSystemService } from '../Services/cart-system.service';
import { ImportantService } from '../Services/important.service';
import { NonVolatileService } from '../Services/non-volatile.service';
import { ProductService } from '../Services/product.service';
import { SharedDataService } from '../Services/shared-data.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styles: [`
    .star {
      font-size: 1.5rem;
      color: #b0c4de;
    }
    .filled {
      color: #1e90ff;
    }
    .bad {
      color: #deb0b0;
    }
    .filled.bad {
      color: #ff1e1e;
    }
  `]
})
// styleUrls: ['./product-detail.component.css']
export class ProductDetailComponent implements OnInit {

  // modalRef: MdbModalRef<RatingModalComponent> | null = null;
  currentRate = 1;
  getmenuId: any;
  datafromService: any;
  products: any;
  filteredArray: any = [];
  cartsystem: CartSystem = new CartSystem();
  user: any;
  productSize: string;
  quantity: any;
  productSizes: any;
  subscription: Subscription;
  title: string;
  Countthings: number;
  cartLength: number;
  btnActive: boolean = false;


  constructor(private productService: ProductService,
    private param: ActivatedRoute,
    private BuyCart: CartSystemService,
    private nonVolatile: NonVolatileService,
    private sharedData: SharedDataService,
    private modalService: MatDialog) { }

  ngOnInit(): void {
    this.GetUser();
    // this.GetCartSystem();
    this.GetProduct();
    this.GetCartSystemBySpecificUser();
    // this.sharedData.changeMessage(this.cartLength);
  }

  GetProduct() {
    this.productService.GetProduct()
      .subscribe((data) => {
        this.products = data;
        this.getmenuId = this.param.snapshot.paramMap.get('id');
        if (this.getmenuId) {
          this.datafromService = this.products;
          this.filteredArray = this.datafromService.filter((Result: any) => {
            return (Result.id == this.getmenuId);
          })
          console.log(this.filteredArray);
          this.btnActive = true;
        }

      })
  }

  PostCartSystem() {
    this.btnActive = false;
    this.cartsystem.image = this.filteredArray[0].productImages[0].pics || {};
    this.quantity = (<HTMLInputElement>document.getElementById("product-quanity")).value;
    this.productSizes = (<HTMLInputElement>document.getElementById("product-size")).value;
    this.cartsystem.productSize.name = this.productSizes;
    this.cartsystem.name = this.filteredArray[0].name;
    this.cartsystem.price = this.filteredArray[0].price;
    this.cartsystem.quantity = this.quantity;
    this.cartsystem.colors.name = this.filteredArray[0].colors.name;
    this.cartsystem.username = this.user;
    console.log(this.productSizes);
    console.log(this.quantity);
    console.log(this.cartsystem);
    this.BuyCart.PostCategory(this.cartsystem).subscribe({
      next: (data) => {
        debugger;
        console.log(data);
        console.log("Id = " + this.getmenuId);
        this.modalService.open(RatingModalComponent, {
          data: { id: this.filteredArray[0] }
        })
        this.btnActive = true;

        // this.ngbModalService.open(RatingModalComponent)

        // const modalRe = this.modalService.open(RatingModalComponent, {
        //   data: this.getmenuId
        // });
      }
    })

  }

  // GetCartSystem() {
  //   this.BuyCart.GetCartSystemByUsername(this.user).subscribe({
  //     next: (data) => {
  //       console.log(data.length);
  //       this.Countthings = data.length;
  //     }
  //   })
  // }

  addToCart() {
    debugger;
    this.PostCartSystem();
    this.GetCartSystemBySpecificUser();

  }

  GetUser() {
    this.user = this.nonVolatile.GetDataToLocalStorage().username;
  }

  GetCartSystemBySpecificUser() {
    debugger;
    this.BuyCart.GetCartSystemByUsername(this.user).subscribe({
      next: (data) => {
        debugger;
        this.cartLength = data.length;
        console.log(data.length);
        this.sharedData.changeMessage(this.cartLength);
      }
    });
  }

}
