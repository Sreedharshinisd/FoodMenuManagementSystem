import { Component } from '@angular/core';
import { FoodItemComponent } from './components/food-item/food-item';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FoodItemComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
}