import { Component, Inject, OnInit } from '@angular/core';
import { MdbModalRef, MdbModalService } from 'mdb-angular-ui-kit/modal';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ProductService } from 'src/app/Services/product.service';
import { Product } from 'src/app/Model/Product';

@Component({
  selector: 'app-product-modal-admin-pannel',
  templateUrl: './product-modal-admin-pannel.component.html',
  styleUrls: ['./product-modal-admin-pannel.component.css']
})
export class ProductModalAdminPannelComponent implements OnInit {

  constructor(public dialogRef: MatDialogRef<ProductModalAdminPannelComponent>,
    private productService: ProductService,
    @Inject(MAT_DIALOG_DATA) public data: { name: number }) { }

  product: Product = new Product();

  ngOnInit(): void {

    this.GetProduct();
  }

  GetProduct() {

    this.productService.GetProductById(this.data.name).subscribe({
      next: (data) => {
        console.log(data);
        console.log(data);
        this.product = data;
        
      }
    })
  }

}
