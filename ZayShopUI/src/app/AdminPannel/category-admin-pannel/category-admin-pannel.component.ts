import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { Category } from 'src/app/Model/Category';
import { GeneralService } from 'src/app/Services/general.service';

@Component({
  selector: 'app-category-admin-pannel',
  templateUrl: './category-admin-pannel.component.html',
  styleUrls: ['./category-admin-pannel.component.css']
})
export class CategoryAdminPannelComponent implements OnInit, OnDestroy {


  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();
  categories: Category[] = [];
  
  constructor(private generalService: GeneralService,
    private spinnerService: NgxSpinnerService) { }

  ngOnInit(): void {
    this.GetCategory();
  }

  ngOnDestroy(): void {
    this.dtTrigger.unsubscribe();
  }

  GetCategory(){
    this.spinnerService.show();
    this.generalService.GetTopLevelCategory().subscribe({
      next: (data) => {
        console.log(data);
        this.categories = data;
        this.spinnerService.hide();
        this.dtTrigger.next(data);
      }
    })
  }

}
