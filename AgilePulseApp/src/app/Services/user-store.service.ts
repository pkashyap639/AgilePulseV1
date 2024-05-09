import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserStoreService {
  private name$ = new BehaviorSubject<string>('');

  constructor() { }

  // get name
  getNameFromStore(){
    return this.name$.asObservable();
  }

  setNameFromStore(name:string){
    this.name$.next(name);
  }
}
