import { Injectable, inject } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
export const LoginRegisterGuard: CanActivateFn = (
  route: ActivatedRouteSnapshot,
  state: RouterStateSnapshot
) => {

  const router: Router = inject(Router);
  const jwtHelperService: JwtHelperService = inject(JwtHelperService);

  const token = localStorage.getItem("token");
  let expired: boolean;
  try {
    expired = jwtHelperService.isTokenExpired(token);
  } catch {
    expired = true;
  }
  if (token && !expired) {
    router.navigate(["news"]);
  }
  return true;
}