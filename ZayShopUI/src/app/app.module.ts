import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ShopComponent } from './shop/shop.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ModalComponent } from './modal/modal.component';
import { ContactComponent } from './contact/contact.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ModalfrAddComponent } from './modalfr-add/modalfr-add.component';
import { MdbModalConfig, MdbModalModule } from 'mdb-angular-ui-kit/modal';
import { NgxSpinnerModule } from 'ngx-spinner';
import { JwtInterceptorService } from './Helpers/jwt-interceptor.service';
import { FormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CartSystemComponent } from './cart-system/cart-system.component';
import { RootComponent } from './root/root.component';
import { CategoryAdminPannelComponent } from './AdminPannel/category-admin-pannel/category-admin-pannel.component';
import { ProductAdminPannelComponent } from './AdminPannel/product-admin-pannel/product-admin-pannel.component';
import { StatusAdminPannelComponent } from './AdminPannel/status-admin-pannel/status-admin-pannel.component';
import { CartSystemAdminPannelComponent } from './AdminPannel/cart-system-admin-pannel/cart-system-admin-pannel.component';
import { RootAdminPannelComponent } from './AdminPannel/root-admin-pannel/root-admin-pannel.component';
import { HeaderAdminPannelComponent } from './AdminPannel/header-admin-pannel/header-admin-pannel.component';
import { FooterAdminPannelComponent } from './AdminPannel/footer-admin-pannel/footer-admin-pannel.component';
import { SideNavbarAdminPannelComponent } from './AdminPannel/side-navbar-admin-pannel/side-navbar-admin-pannel.component';
import { SharedDataService } from './Services/shared-data.service';
import { DataTablesModule } from 'angular-datatables';
import { UsersAdminPannelComponent } from './AdminPannel/users-admin-pannel/users-admin-pannel.component';
import { SubCatgoryAdminPannelComponent } from './AdminPannel/sub-catgory-admin-pannel/sub-catgory-admin-pannel.component';
import { ProductModalAdminPannelComponent } from './AdminPannel/product-modal-admin-pannel/product-modal-admin-pannel.component';
import { MAT_DIALOG_DATA, MAT_DIALOG_DEFAULT_OPTIONS } from '@angular/material/dialog';
import { MatDialogModule } from '@angular/material/dialog';
import { ToastrModule } from 'ngx-toastr';
import { RatingModalComponent } from './rating-modal/rating-modal.component';
import { MatButtonModule } from '@angular/material/button';

//import { MdCardModule } from '@angular/material';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    HomeComponent,
    AboutComponent,
    ShopComponent,
    ProductDetailComponent,
    ModalComponent,
    ContactComponent,
    UserProfileComponent,
    ModalfrAddComponent,
    CartSystemComponent,
    RootComponent,
    CategoryAdminPannelComponent,
    ProductAdminPannelComponent,
    StatusAdminPannelComponent,
    CartSystemAdminPannelComponent,
    RootAdminPannelComponent,
    HeaderAdminPannelComponent,
    FooterAdminPannelComponent,
    SideNavbarAdminPannelComponent,
    UsersAdminPannelComponent,
    SubCatgoryAdminPannelComponent,
    ProductModalAdminPannelComponent,
    RatingModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    MdbModalModule,
    NgxSpinnerModule,
    FormsModule,
    BrowserAnimationsModule,
    NgxSpinnerModule,
    DataTablesModule,
    MatDialogModule,
    ToastrModule.forRoot(),
    NgbModule,
    MatDialogModule,
    MatButtonModule
    //MdCardModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptorService, multi: true },
    { provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: { hasBackdrop: false } },
    { provide: MAT_DIALOG_DATA, useValue: {} },
    SharedDataService,
    // MdbModalConfig
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
