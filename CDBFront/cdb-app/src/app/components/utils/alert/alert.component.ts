import { Component, OnInit } from '@angular/core';
import { AlertService } from '../../../services/alert.service';

@Component({
  selector: 'app-alert',
  templateUrl: './alert.component.html',
  styleUrls: ['./alert.component.scss'],
})

export class AlertComponent implements OnInit {
  success: string | null = null;
  error: string | null = null;
  warnings: string[] = [];

  constructor(private alertService: AlertService) {}

  ngOnInit() {
    this.alertService.success$.subscribe((msg) => (this.success = msg));
    this.alertService.error$.subscribe((msg) => (this.error = msg));
    this.alertService.warnings$.subscribe((msgs) => (this.warnings = msgs));
  }
}