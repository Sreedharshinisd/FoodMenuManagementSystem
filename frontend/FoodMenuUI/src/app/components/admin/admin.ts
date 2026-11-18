
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import {
  FoodItem,
  CreateFoodItem,
  UpdateFoodItem
} from '../../models/food-item.model';

import { FoodItemService } from '../../services/food-item.service';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './admin.html',
  styleUrl: './admin.css'
})
export class AdminComponent implements OnInit {

  foodItems: FoodItem[] = [];

  foodName = '';
  description = '';
  price: number | null = null;
  imageUrl = '';
  isAvailable = true;

  showForm = false;
  editingFoodItemId: number | null = null;

  errorMessage = '';
  successMessage = '';

  constructor(
    private foodItemService: FoodItemService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadFoodItems();
  }

  loadFoodItems(): void {
    this.foodItemService.getFoodItems().subscribe({
      next: (data) => {
        this.foodItems = data;
        this.cdr.markForCheck();
        console.log('Food items count:', this.foodItems.length);
      },
      error: (error) => {
        console.error('Error loading food items:', error);
        this.errorMessage = 'Unable to load food items.';
      }
    });
  }

  openAddForm(): void {
    this.resetForm();
    this.showForm = true;
  }

  editFoodItem(item: FoodItem): void {

    this.editingFoodItemId = item.foodItemId;
    this.foodName = item.foodName;
    this.description = item.description || '';
    this.price = item.price;
    this.imageUrl = item.imageUrl || '';
    this.isAvailable = item.isAvailable;

    this.showForm = true;

    this.errorMessage = '';
    this.successMessage = '';

    // Scroll automatically to the edit form
    setTimeout(() => {
      document.getElementById('food-item-form')?.scrollIntoView({
        behavior: 'smooth',
        block: 'start'
      });
    }, 100);
  }

  saveFoodItem(): void {

    if (!this.foodName.trim() || this.price === null || this.price <= 0) {
      this.errorMessage = 'Enter a valid food name and price.';
      return;
    }

    this.errorMessage = '';
    this.successMessage = '';

    if (this.editingFoodItemId === null) {

      const foodItem: CreateFoodItem = {
        foodName: this.foodName.trim(),
        description: this.description.trim() || null,
        price: this.price,
        imageUrl: this.imageUrl.trim() || null
      };

      this.foodItemService.addFoodItem(foodItem).subscribe({
        next: () => {
          this.successMessage = 'Food item added successfully!';
          this.resetForm();
          this.loadFoodItems();
        },
        error: (error) => {
          console.error(error);
          this.errorMessage = 'Unable to add food item.';
        }
      });

    } else {

      const foodItem: UpdateFoodItem = {
        foodName: this.foodName.trim(),
        description: this.description.trim() || null,
        price: this.price,
        imageUrl: this.imageUrl.trim() || null,
        isAvailable: this.isAvailable
      };

      this.foodItemService.updateFoodItem(
        this.editingFoodItemId,
        foodItem
      ).subscribe({
        next: () => {
          this.successMessage = 'Food item updated successfully!';
          this.resetForm();
          this.loadFoodItems();
        },
        error: (error) => {
          console.error(error);
          this.errorMessage = 'Unable to update food item.';
        }
      });
    }
  }

  deleteFoodItem(id: number): void {

    if (!confirm('Are you sure you want to delete this food item?')) {
      return;
    }

    this.foodItemService.deleteFoodItem(id).subscribe({
      next: () => {
        this.successMessage = 'Food item deleted successfully!';
        this.loadFoodItems();
      },
      error: (error) => {
        console.error(error);
        this.errorMessage = 'Unable to delete food item.';
      }
    });
  }

  resetForm(): void {
    this.foodName = '';
    this.description = '';
    this.price = null;
    this.imageUrl = '';
    this.isAvailable = true;
    this.editingFoodItemId = null;
    this.showForm = false;
    this.errorMessage = '';
  }

  getAvailableCount(): number {
    return this.foodItems.filter(item => item.isAvailable).length;
  }
}
