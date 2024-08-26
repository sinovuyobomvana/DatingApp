import { inject, Injectable } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs/operators';

export const adminGuard: CanActivateFn = (route, state) => {
    const accountSerivce = inject(AccountService);
    const toastr = inject(ToastrService);
    
  return accountSerivce.currentUser$.pipe(
  map(user => {
    if(!user) return false;
    if(user.roles.includes('Admin') || user.roles.includes('Moderator')){
      return true;
    }
    else{
      toastr.error('You cannot enter this area')
      return false;
    }
  })
  )
  };
