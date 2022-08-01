import { HttpErrorResponse } from '@angular/common/http';
import { Component, Inject, Input, OnInit, Optional } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MdbModalRef } from 'mdb-angular-ui-kit/modal';
import { Rate } from '../Model/Rate';
import { NonVolatileService } from '../Services/non-volatile.service';
import { NotificationService } from '../Services/notification.service';
import { RatingService } from '../Services/rating.service';

@Component({
  selector: 'app-rating-modal',
  templateUrl: './rating-modal.component.html',
  styleUrls: ['./rating-modal.component.css'],
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
export class RatingModalComponent implements OnInit {

  rate: Rate = new Rate();
  rating: number = 1;
  @Input() name: any;
  username: any;
  constructor(private nonvolatile: NonVolatileService,
    private ratingService: RatingService,
    private notificationService: NotificationService,
    @Optional() @Inject(MAT_DIALOG_DATA) private data: any
  ) { }

  ngOnInit(): void {
    this.GetUser();
  }

  PostRate() {
    debugger;
    this.rate.rating = this.rating;
    this.rate.productId = this.data.id.id;
    this.ratingService.PostRate(this.rate).subscribe({
      next: (data) => {
        console.log(data);
      }, error: (e: HttpErrorResponse) => {
        this.notificationService.showError(e.message, e.error)
      }
    })
  }

  GetUser() {
    this.username = this.nonvolatile.GetDataToLocalStorage().username;
  }

}
