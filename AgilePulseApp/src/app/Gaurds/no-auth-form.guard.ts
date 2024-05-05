import { Token } from '@angular/compiler';
import { CanDeactivateFn, Router } from '@angular/router';

export const noAuthFormGuard: CanDeactivateFn<unknown> = (component, currentRoute, currentState, nextState) => {
  const token = sessionStorage.getItem('Token')
  if(token){
    const route = new Router()
    route.navigate(['dashboard'])
    return false
  }
  return true
};
