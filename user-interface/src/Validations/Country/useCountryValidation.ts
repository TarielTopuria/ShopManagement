import { useState } from 'react';
import { CountryCreationModel } from '../../Models/CountryCreationModel';

const useCountryValidation = () => {
  const [countryValidationErrors, setValidationErrors] = useState({
    name: ''
  });

  const validateCountry = (country: CountryCreationModel) => {
    const errors = {
      ...countryValidationErrors,
      name: validateName(country.name)
    };

    setValidationErrors(errors);
    return Object.values(errors).some(error => error !== '');
  };

  const validateName = (name: string) => {
    if (!name) return "ქვეყნის დასახელების მითითება აუცილებელია.";
    if (name.length > 100) return "ქვეყნის დასახელება არ უნდა იყოს 100 სიმბოლოზე მეტი.";
    return '';
  };

  return { validateCountry, countryValidationErrors };
};

export default useCountryValidation;
