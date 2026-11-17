
import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Menu, CreateMenu } from '../models/menu.model';

@Injectable({
  providedIn: 'root'
})
export class MenuService {

  private http = inject(HttpClient);

  private apiUrl = 'http://localhost:5211/api/Menu';
  getMenus(): Observable<Menu[]> {
    return this.http.get<Menu[]>(this.apiUrl);
  }

  addMenu(menu: CreateMenu): Observable<Menu> {
    return this.http.post<Menu>(this.apiUrl, menu);
  }
}
