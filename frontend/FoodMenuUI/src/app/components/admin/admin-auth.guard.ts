import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';

export const adminAuthGuard: CanActivateFn = () => {

  const router = inject(Router);
  const token = localStorage.getItem('adminToken');

  if (token) {
    return true;
  }

  return router.createUrlTree(['/admin-login']);
};