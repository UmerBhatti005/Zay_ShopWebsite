import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Subject } from 'rxjs';
import { CartSystem } from 'src/app/Model/CartSystem';
import { CartSystemService } from 'src/app/Services/cart-system.service';

@Component({
  selector: 'app-cart-system-admin-pannel',
  templateUrl: './cart-system-admin-pannel.component.html',
  styleUrls: ['./cart-system-admin-pannel.component.css']
})
export class CartSystemAdminPannelComponent implements OnInit {

  dtOptions: DataTables.Settings = {};
  dtTrigger: Subject<any> = new Subject<any>();
  cartsystem: CartSystem[] = [];
  UpdatedCartSystem: CartSystem = new CartSystem();
  report: any;
  reportId: number;
  constructor(private cartSystemService: CartSystemService,
    private spinnerService: NgxSpinnerService) { }

  ngOnInit(): void {

    this.GetCartSystem();
  }

  GetCartSystem() {
    this.spinnerService.show();
    this.cartSystemService.GetCartSystem().subscribe({
      next: (data) => {
        console.log(data);
        this.cartsystem = data;
        this.spinnerService.hide();
        this.dtTrigger.next(data);
      }
    })
  }

  reportChange(id: number) {
    this.reportId = id;
  }

  UpdateCartSystem(data: CartSystem, report: any) {
    console.log(data);
    console.log(report);

    this.UpdatedCartSystem.id = data.id;
    this.UpdatedCartSystem.name = data.name;
    this.UpdatedCartSystem.price = data.price;
    this.UpdatedCartSystem.image = data.image;
    this.UpdatedCartSystem.quantity = data.quantity
    this.UpdatedCartSystem.colors.id = data.colors.id;
    this.UpdatedCartSystem.productSize.id = data.productSize.id;
    this.UpdatedCartSystem.report.id = report;
    this.UpdatedCartSystem.username = data.username;
    this.cartSystemService.PutCartSystem(this.UpdatedCartSystem).subscribe({
      next: (data) => {
        console.log(data);
      }
    })
  }

}
