import { Component, OnDestroy, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { Product } from 'src/app/Model/Product';
import { NotificationService } from 'src/app/Services/notification.service';
import { ProductService } from 'src/app/Services/product.service';

@Component({
  selector: 'app-product-admin-pannel',
  templateUrl: './product-admin-pannel.component.html',
  styleUrls: ['./product-admin-pannel.component.css']
})
export class ProductAdminPannelComponent implements OnInit, OnDestroy {

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();
  products: Product[] = [];
  UpdatedProduct: Product = new Product();

  constructor(private productService: ProductService,
    private SpinnerService: NgxSpinnerService,
    private notificationService: NotificationService) { }

  ngOnInit(): void {
    this.GetProducts();
  }

  GetProducts() {
    this.SpinnerService.show();
    this.productService.GetProductsForAdmin().subscribe({
      next: (data) => {
        console.log(data);
        this.products = data;
        this.SpinnerService.hide();
        this.dtTrigger.next(this.products);
      }
    })
  }

  UpdateProduct(data: Product, status: any) {

    this.UpdatedProduct.id = data.id;
    this.UpdatedProduct.name = data.name;
    this.UpdatedProduct.price = data.price;
    this.UpdatedProduct.quantity = data.quantity;
    this.UpdatedProduct.description = data.description;
    this.UpdatedProduct.isFeatured = data.isFeatured;
    this.UpdatedProduct.noofSales = data.noofSales;
    this.UpdatedProduct.postedDate = data.postedDate;
    this.UpdatedProduct.description = data.description;
    this.UpdatedProduct.categories.id = data.categories.id;
    this.UpdatedProduct.colors.id = data.colors.id;
    this.UpdatedProduct.genders.id = data.genders.id;
    this.UpdatedProduct.statuses.id = status;
    this.UpdatedProduct.productImages = data.productImages;
    this.UpdatedProduct.productSizes.id = data.productSizes.id;
    this.UpdatedProduct.username = data.username;
    
    this.productService.UpdateProduct(this.UpdatedProduct).subscribe({
      next: (data) => {
        debugger;
        console.log(data);
        console.log(this.UpdatedProduct);
        this.notificationService.showInfo("Status Updated Successfully", "Update Product");
      }, error: (error: Response) => {
        this.notificationService.showError(error.text.name, error.formData.name);
      }
    })
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  edit(id: number) {

  }

}
