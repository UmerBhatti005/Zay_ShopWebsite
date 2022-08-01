import { Component, OnInit } from '@angular/core';
import { Product } from '../Model/Product';
import { ProductService } from '../Services/product.service';

@Component({
  selector: 'app-check',
  templateUrl: './check.component.html',
  styleUrls: ['./check.component.css']
})
export class CheckComponent implements OnInit {

  products:Product[] = [];

  constructor(private productService: ProductService) { }

  ngOnInit(): void {
    this.GetProduct();
  }

  GetProduct(){
    this.productService.GetProduct()
    .subscribe((data) => {
      console.log(data);
      this.products = data;
      console.log(this.products);
      
    })
  }

}
