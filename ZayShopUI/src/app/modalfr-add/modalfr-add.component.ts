import { getLocaleFirstDayOfWeek } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { MdbModalRef } from 'mdb-angular-ui-kit/modal';
import { Observable, ReplaySubject } from 'rxjs';
import { Category } from '../Model/Category';
import { Product } from '../Model/Product';
import { GeneralService } from '../Services/general.service';
import { ImportantService } from '../Services/important.service';
import { NonVolatileService } from '../Services/non-volatile.service';
import { ProductService } from '../Services/product.service';
import { StatusService } from '../Services/status.service';

@Component({
  selector: 'app-modalfr-add',
  templateUrl: './modalfr-add.component.html',
  styleUrls: ['./modalfr-add.component.css'
  ]
})
export class ModalfrAddComponent implements OnInit {

  // categories:Category = new Category();
  // statuses:Status = new Status();
  products: Product[] = [];
  product: Product = new Product();
  category: Category[] = [];
  cat: any;
  SubCategory: any;
  statuss: any;
  base64Output: string;
  categories: Category = new Category();
  rank: number = 0;
  SubCat_Par: number = 0;
  data: any;
  Username: any;
  colors: number = 0;
  productSizes: number = 0;
  colorses: any;
  sizes: any;
  // constructor(public activeModal: NgbActiveModal) { }
  constructor(public modalRef: MdbModalRef<ModalfrAddComponent>,
    public service: ProductService,
    private generalService: GeneralService,
    private statusService: StatusService,
    private nonVolatile: NonVolatileService,
    private importanatService: ImportantService,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.GetTopLevelCategories();
    this.GetStatuses();
    this.getUsersData();
    this.GetColors();
    this.GetProductSizes();
  }

  getUsersData() {
    this.data = this.nonVolatile.GetDataToLocalStorage();
    this.Username = this.data.username;
  }

  GetColors() {
    this.importanatService.GetColors().subscribe({
      next: (data) => {
        this.colorses = data;
      }, error: (e) => {
        alert("An Error Occured");
      }
    });
  }

  GetProductSizes() {
    this.importanatService.GetProductSizes().subscribe({
      next: (data) => {
        console.log(data);
        this.sizes = data
      }
    })
  }


  // Event of according to change of category, subcategory shown.
  onChange(event: Event) {
    this.cat = (event.target as HTMLInputElement).value;
    console.log(this.cat);
    this.GetSubCategories();

  }

  //  Function of getting subcategories
  GetSubCategories() {
    this.generalService.GetSubcategory(this.cat)
      .subscribe((data) => {
        console.log(data);
        this.SubCategory = data;

      })
  }

  //function of getting topLevelcategories
  GetTopLevelCategories() {
    this.generalService.GetTopLevelCategory()
      .subscribe((data) => {
        console.log(data);
        this.category = data;
        console.log(this.category);
      });
  }

  // function of posting product
  PostProduct() {
    this.product.categories.id = this.SubCat_Par;
    this.product.colors.id = this.colors;
    this.product.productSizes.id = this.productSizes;
    this.product.username = this.Username;
    this.product.isFeatured = false;
    this.product.noofSales = 10;
    this.product.statuses.id = 1;
    this.product.genders.id = 1;
    this.service.PostProduct(this.product)
      .subscribe({
        next: (data) => {
          debugger;
          console.log(data);
          console.log(this.SubCat_Par);
          console.log(this.colors);
          this.service.GetProduct();
          console.log(this.product);

        }, error: ((error: Response) => {
          alert("An error Occured" + error);
        })
      })
    console.log(this.product);
  }

  // function of getting statuses

  GetStatuses() {
    this.statusService.GetStatuses()
      .subscribe({
        next: (data) => {
          console.log(data);
          this.statuss = data;
        }, error: (e) => {
          alert("Error" + e);
        }
      })
  }

  onsubmit() {
    console.log(this.rank);
    this.PostProduct();
    this.router.navigate(['/UserProfile']);

  }

  onFileSelected(event: any) {
    for (let i = 0; i < event.target.files.length; i++) {
      debugger;
      this.convertFile(event.target.files[i]).subscribe(base64 => {
        if (event.target.files.length != null) {
          debugger;
          console.log(base64);

          let productImg = {
            "rank": this.rank,
            "pics": base64,
            "caption": "Image-" + (i + 1)
          };
          debugger;
          this.product.productImages.push(productImg);
        }
      });
    }

  }

  convertFile(file: File): Observable<string> {
    const result = new ReplaySubject<string>(1);
    const reader = new FileReader();
    reader.readAsBinaryString(file);
    reader.onload = (event: any) => result.next(btoa(event.target.result.toString()));
    return result;
  }

}
