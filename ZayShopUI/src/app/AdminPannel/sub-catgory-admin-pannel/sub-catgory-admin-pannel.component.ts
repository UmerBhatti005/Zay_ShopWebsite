import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { Category } from 'src/app/Model/Category';
import { GeneralService } from 'src/app/Services/general.service';

@Component({
  selector: 'app-sub-catgory-admin-pannel',
  templateUrl: './sub-catgory-admin-pannel.component.html',
  styleUrls: ['./sub-catgory-admin-pannel.component.css']
})
export class SubCatgoryAdminPannelComponent implements OnInit {

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();
  subcategories: Category[] =[];
  constructor(private categoryService: GeneralService,
    private spinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    this.GetSubCatgories();
  }

  GetSubCatgories(){
    this.spinnerService.show();
    this.categoryService.GetSubCategories().subscribe({
      next: (data) => {
        console.log(data);
        this.subcategories = data;
        this.spinnerService.hide();
        this.dtTrigger.next(data);
      }
    })
  }
}
