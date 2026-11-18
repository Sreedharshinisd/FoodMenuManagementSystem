import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { AdminAuthService } from '../../services/admin-auth.service';

@Component({
  selector: 'app-admin-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './admin-login.html',
  styleUrl: './admin-login.css'
})
export class AdminLoginComponent {

  email = '';
  password = '';
  errorMessage = '';

  constructor(
    private authService: AdminAuthService,
    private router: Router
  ) {}

  login(): void {
    this.errorMessage = '';

    this.authService.login(this.email, this.password).subscribe({
      next: (response) => {
        localStorage.setItem('adminToken', response.token);
        this.router.navigate(['/admin']);
      },
      error: () => {
        this.errorMessage = 'Invalid email or password';
      }
    });
  }
}