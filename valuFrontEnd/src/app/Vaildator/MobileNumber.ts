import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function egyptianMobileNumberValidator(): ValidatorFn {
  return (control: AbstractControl): ValidationErrors | null => {
    const valid = /^(010|011|012|015)\d{8}$/.test(control.value);
    return valid ? null : { invalidEgyptianMobileNumber: true };
  };
}
