export interface FoodItem {
  foodItemId: number;
  foodName: string;
  description?: string | null;
  price: number;
  imageUrl?: string | null;
  isAvailable: boolean;
}

export interface CreateFoodItem {
  foodName: string;
  description?: string | null;
  price: number;
  imageUrl?: string | null;
}

export interface UpdateFoodItem {
  foodName: string;
  description?: string | null;
  price: number;
  imageUrl?: string | null;
  isAvailable: boolean;
}