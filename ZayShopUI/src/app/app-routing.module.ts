import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { CartSystemAdminPannelComponent } from './AdminPannel/cart-system-admin-pannel/cart-system-admin-pannel.component';
import { CategoryAdminPannelComponent } from './AdminPannel/category-admin-pannel/category-admin-pannel.component';
import { ProductAdminPannelComponent } from './AdminPannel/product-admin-pannel/product-admin-pannel.component';
import { RootAdminPannelComponent } from './AdminPannel/root-admin-pannel/root-admin-pannel.component';
import { SubCatgoryAdminPannelComponent } from './AdminPannel/sub-catgory-admin-pannel/sub-catgory-admin-pannel.component';
import { UsersAdminPannelComponent } from './AdminPannel/users-admin-pannel/users-admin-pannel.component';
import { CartSystemComponent } from './cart-system/cart-system.component';
import { ContactComponent } from './contact/contact.component';
import { AdminAuthGuardService } from './Helpers/admin-auth-guard.service';
import { AuthGuardService } from './Helpers/auth-guard.service';
import { HomeComponent } from './home/home.component';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { RootComponent } from './root/root.component';
import { ShopComponent } from './shop/shop.component';
import { UserProfileComponent } from './user-profile/user-profile.component';

// const accountModule = () => import('./account/account.module').then(x => x.AccountModule);
const usersModule = () => import('./Users/user.module').then(x => x.UserModule);


// const routes: Routes = [
//   {
//     path: '', component: HomeComponent, canActivate: [AuthGuardService]
//   },
//   {
//     path: 'users', loadChildren: usersModule
//   },
//   {
//     path: 'index', component: HomeComponent
//   },
//   {
//     path: 'about', component: AboutComponent
//   },
//   {
//     path: 'shop', component: ShopComponent
//   },
//   {
//     path: 'contact', component: ContactComponent
//   },
//   {
//     path: 'details', component: ProductDetailComponent
//   },
//   {
//     path: 'details/:id', component: ProductDetailComponent
//   },
//   {
//     path: 'UserProfile', component: UserProfileComponent, canActivate: [AuthGuardService]
//   },
//   {
//     path: 'CartSystem', component: CartSystemComponent
//   },
//   { path: '**', redirectTo: '' }
// ];

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: '', component: HomeComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'index', component: HomeComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'about', component: AboutComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'shop', component: ShopComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'contact', component: ContactComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'details', component: ProductDetailComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'details/:id', component: ProductDetailComponent, canActivate: [AuthGuardService]
      },
      {
        path: 'UserProfile', component: UserProfileComponent, canActivate: [AuthGuardService]
      }
    ], component: RootComponent
  },
  {
    path: 'Admin',
    children: [
      {
        path: '', component: CategoryAdminPannelComponent, canActivate: [AdminAuthGuardService]
      },
      {
        path: 'CategoryPanel', component: CategoryAdminPannelComponent, canActivate: [AdminAuthGuardService]
      },
      {
        path: 'SubCategoryPanel', component: SubCatgoryAdminPannelComponent, canActivate: [AdminAuthGuardService]
      },
      {
        path: 'ProductPanel', component: ProductAdminPannelComponent, canActivate: [AdminAuthGuardService]
      },
      {
        path: 'UserPanel', component: UsersAdminPannelComponent, canActivate: [AdminAuthGuardService]
      },
      {
        path: 'CartSystemPanel', component: CartSystemAdminPannelComponent, canActivate: [AdminAuthGuardService]
      }
      
    ], component: RootAdminPannelComponent
  },
  {
    path: 'CartSystem', component: CartSystemComponent, canActivate: [AuthGuardService]
  },
  {
    path: 'users', loadChildren: usersModule
  },
  { path: '**', redirectTo: '' }
];
RouterModule.forRoot([
  { path: 'details', component: ProductDetailComponent },
]);

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
