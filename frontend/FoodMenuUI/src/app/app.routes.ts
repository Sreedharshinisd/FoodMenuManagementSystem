import { Routes } from '@angular/router';
import { FoodItemComponent } from './components/food-item/food-item';
import { MenuComponent } from './components/menu/menu';

export const routes: Routes = [
  {
    path: '',
    component: FoodItemComponent
  },
  {
    path: 'menus',
    component: MenuComponent
  },
  {
    path: '**',
    redirectTo: ''
  }
];