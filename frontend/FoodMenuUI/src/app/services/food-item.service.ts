
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {
  FoodItem,
  CreateFoodItem,
  UpdateFoodItem
} from '../models/food-item.model';

@Injectable({
  providedIn: 'root'
})
export class FoodItemService {

  private apiUrl = 'http://localhost:5211/api/FoodItem';

  constructor(private http: HttpClient) {}

  getFoodItems(): Observable<FoodItem[]> {
    return this.http.get<FoodItem[]>(this.apiUrl);
  }

  getFoodItemById(id: number): Observable<FoodItem> {
    return this.http.get<FoodItem>(`${this.apiUrl}/${id}`);
  }

  addFoodItem(foodItem: CreateFoodItem): Observable<FoodItem> {
    return this.http.post<FoodItem>(this.apiUrl, foodItem);
  }

  updateFoodItem(id: number, foodItem: UpdateFoodItem): Observable<FoodItem> {
    return this.http.put<FoodItem>(`${this.apiUrl}/${id}`, foodItem);
  }

  deleteFoodItem(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
