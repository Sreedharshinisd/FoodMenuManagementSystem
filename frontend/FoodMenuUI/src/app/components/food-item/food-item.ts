
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FoodItem } from '../../models/food-item.model';
import { FoodItemService } from '../../services/food-item.service';

@Component({
  selector: 'app-food-item',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './food-item.html',
  styleUrl: './food-item.css'
})
export class FoodItemComponent implements OnInit {

  foodItems: FoodItem[] = [];
  errorMessage = '';
  isLoading = true;

  constructor(
    private foodItemService: FoodItemService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadFoodItems();
  }

  loadFoodItems(): void {
    this.isLoading = true;

    this.foodItemService.getFoodItems().subscribe({
      next: (data) => {
        console.log('Food items received:', data);

        this.foodItems = data;
        this.isLoading = false;

        this.cdr.markForCheck();
      },
      error: (error) => {
        console.error('Error loading food items:', error);

        this.errorMessage = 'Unable to load food items. Please try again.';
        this.isLoading = false;

        this.cdr.markForCheck();
      }
    });
  }

  onImageError(event: Event): void {
    (event.target as HTMLImageElement).style.display = 'none';
  }
}
