
import { Component, OnInit, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MenuService } from '../../services/menu.service';
import { Menu } from '../../models/menu.model';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './menu.html',
  styleUrl: './menu.css'
})
export class MenuComponent implements OnInit {

  private menuService = inject(MenuService);

  menus: Menu[] = [];

  menuName = '';
  description = '';

  loading = false;
  saving = false;
  errorMessage = '';
  successMessage = '';

  showForm = false;

  ngOnInit(): void {
    this.loadMenus();
  }

  loadMenus(): void {
    this.loading = true;
    this.errorMessage = '';

    this.menuService.getMenus().subscribe({
      next: (data) => {
        this.menus = data;
        this.loading = false;
      },
      error: () => {
        this.errorMessage = 'Unable to load menus. Please check whether the API is running.';
        this.loading = false;
      }
    });
  }

  addMenu(): void {
    if (!this.menuName.trim()) {
      this.errorMessage = 'Please enter a menu name.';
      return;
    }

    this.saving = true;
    this.errorMessage = '';
    this.successMessage = '';

    this.menuService.addMenu({
      menuName: this.menuName.trim(),
      description: this.description.trim()
    }).subscribe({
      next: () => {
        this.menuName = '';
        this.description = '';
        this.showForm = false;
        this.saving = false;
        this.successMessage = 'Menu added successfully!';
        this.loadMenus();
      },
      error: () => {
        this.errorMessage = 'Unable to add menu. Please try again.';
        this.saving = false;
      }
    });
  }
}
