
import { Routes } from '@angular/router';

import { FoodItemComponent } from './components/food-item/food-item';
import { MenuComponent } from './components/menu/menu';
import { AdminComponent } from './components/admin/admin';
import { AdminLoginComponent } from './components/admin-login/admin-login';
import { adminAuthGuard } from './guards/admin-auth-guard';

export const routes: Routes = [
  { path: '', component: FoodItemComponent },
  { path: 'menus', component: MenuComponent },
  { path: 'admin-login', component: AdminLoginComponent },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [adminAuthGuard]
  },
  { path: '**', redirectTo: '' }
];
