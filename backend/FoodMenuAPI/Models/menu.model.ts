
export interface Menu {
  menuId: number;
  menuName: string;
  description: string | null;
  isActive: boolean;
}

export interface CreateMenu {
  menuName: string;
  description: string;
}
