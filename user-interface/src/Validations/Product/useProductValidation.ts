// useProductValidation.ts
import { useState } from 'react';
import { ProductCreationModel } from '../../Models/ProductCreationModel';

const useProductValidation = () => {
    const [validationErrors, setValidationErrors] = useState({
        code: '',
        name: '',
        price: '',
        startDate: '',
        endDate: '',
        countryId: '',
        groupId: '',
    });

    const validateProduct = (product: ProductCreationModel) => {
        const errors = {
            ...validationErrors,
            code: validateCode(product.code),
            name: validateName(product.name),
            price: validatePrice(product.price),
            startDate: validateDates(product.startDate, product.endDate),
            countryId: validateCountryId(product.countryId),
            groupId: validateGroupId(product.groupId)
        };

        setValidationErrors(errors);
        return Object.values(errors).some(error => error !== '');
    };

    const validateCode = (code: string) => {
        if (!code) return "კოდის მითითება აუცილებელია.";
        if (!/^[0-9]+$/.test(code)) return "კოდი უნდა შედგებოდეს მხოლოდ რიცხვითი მნიშვნელობისგან.";
        if (code.length < 3 || code.length > 10) return "კოდი უნდა შედგებოდეს 3-დან 10 სიმბოლომდე.";
        return '';
      };

      const validateName = (name: string) => {
        if (!name) return "დასახელების მითითება აუცილებელია.";
        if (name.length > 100) return "დასახელება არ უნდა იყოს 100 სიმბოლოზე მეტი.";
        return '';
      };

      const validatePrice = (price: number) => {
        if (!price || price < 0) return "ფასი უნდა იყოს 0-ზე მეტი.";
        return '';
      };

      const validateDates = (startDate: Date, endDate: Date) => {
        if (startDate >= endDate) {
          return "საწყისი თარიღი უნდა იყოს საბოლოო თარიღზე მეტი.";
        }
        return '';
      };
      
      const validateCountryId = (countryId: number) => {
        if (!countryId || countryId < 0) return "ქვეყნის მითითება აუცილებელია";
        return '';
      };

      const validateGroupId = (groupId: number | undefined) => {
        if (!groupId || groupId < 0) return "ჯგუფის მითითება აუცილებელია";
        return '';
      };

    return { validateProduct, validationErrors };
};

export default useProductValidation;
