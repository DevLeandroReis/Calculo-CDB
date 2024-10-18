import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class AlertService {
  private successSubject = new BehaviorSubject<string | null>(null);
  private errorSubject = new BehaviorSubject<string | null>(null);
  private warningsSubject = new BehaviorSubject<string[]>([]);

  success$ = this.successSubject.asObservable();
  error$ = this.errorSubject.asObservable();
  warnings$ = this.warningsSubject.asObservable();

  showSuccess(message: string) {
    this.successSubject.next(message);
    this.startTimeout(() => this.clearSuccess());
  }

  showError(message: string) {
    this.errorSubject.next(message);
    this.startTimeout(() => this.clearError());
  }

  showWarnings(messages: string[]) {
    this.warningsSubject.next(messages);
    this.startTimeout(() => this.clearWarnings());
  }

  private startTimeout(callback: () => void) {
    setTimeout(callback, 7000);
  }

  clearSuccess() {
    this.successSubject.next(null);
  }

  clearError() {
    this.errorSubject.next(null);
  }

  clearWarnings() {
    this.warningsSubject.next([]);
  }
}