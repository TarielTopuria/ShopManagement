import { useState } from 'react';
import { GroupCreationModel } from '../../Models/GroupCreationModel';

const useGroupValidation = () => {
  const [groupValidationErrors, setValidationErrors] = useState({
    name: '',
    parentGroupId: '',
  });

  const validateGroup = (group: GroupCreationModel) => {
    const errors = {
      ...groupValidationErrors,
      name: validateName(group.name),
    };

    setValidationErrors(errors);
    return Object.values(errors).some(error => error !== '');
  };

  const validateName = (name: string) => {
    if (!name) return "ჯგუფის დასახელების მითითება აუცილებელია.";
    if (name.length > 100) return "ჯგუფის დასახელება არ უნდა იყოს 100 სიმბოლოზე მეტი.";
    return '';
  };

  return { validateGroup, groupValidationErrors };
};

export default useGroupValidation;
