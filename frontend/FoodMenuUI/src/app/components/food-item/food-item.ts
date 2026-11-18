
import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { FoodItem } from '../../models/food-item.model';
import { FoodItemService } from '../../services/food-item.service';
import { Menu } from '../../models/menu.model';
import { MenuService } from '../../services/menu.service';

@Component({
  selector: 'app-food-item',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './food-item.html',
  styleUrl: './food-item.css'
})
export class FoodItemComponent implements OnInit {

  foodItems: FoodItem[] = [];
  menus: Menu[] = [];

  errorMessage = '';
  menuErrorMessage = '';
  isLoading = true;
  isMenuLoading = true;

  constructor(
    private foodItemService: FoodItemService,
    private menuService: MenuService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    this.loadFoodItems();
    this.loadMenus();
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

  loadMenus(): void {
    this.isMenuLoading = true;

    this.menuService.getMenus().subscribe({
      next: (data) => {
        console.log('Menus received:', data);
        this.menus = data;
        this.isMenuLoading = false;
        this.cdr.markForCheck();
      },
      error: (error) => {
        console.error('Error loading menus:', error);
        this.menuErrorMessage = 'Unable to load menus.';
        this.isMenuLoading = false;
        this.cdr.markForCheck();
      }
    });
  }

  onImageError(event: Event): void {
    (event.target as HTMLImageElement).style.display = 'none';
  }
}
