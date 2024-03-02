import React, { useEffect, useState } from 'react';
import { Group } from '../../Models/Group';
import { Modal, Button, Form, Row, Col } from 'react-bootstrap';
import { GroupCreationModel } from '../../Models/GroupCreationModel';
import { GroupEditionModel } from '../../Models/GroupEditionModel';
import Select, { SingleValue } from 'react-select';
import useGroupValidation from '../../Validations/Group/useGroupValidation';

interface AddGroupModalProps {
  show: boolean;
  handleClose: () => void;
  onSave: (groupData: GroupCreationModel | GroupEditionModel) => void;
  allGroups: Group[];
  isEditMode: boolean;
  initialGroupName: string;
  initialParentGroupId: number | null;
}

interface GroupOption {
  value: number | null;
  label: string;
}

const AddGroupModal: React.FC<AddGroupModalProps> = ({ show, handleClose, onSave, allGroups, isEditMode, initialGroupName, initialParentGroupId }) => {
  const [groupName, setGroupName] = useState<string>('');
  const [selectedParentGroupId, setSelectedParentGroupId] = useState<number | null>(null);
  const { validateGroup, groupValidationErrors } = useGroupValidation();

  const flattenGroups = (groups: Group[], flattened: GroupOption[] = []): GroupOption[] => {
    groups.forEach(group => {
      flattened.push({ value: group.id, label: group.name });
      if (group.subgroups) {
        flattenGroups(group.subgroups, flattened);
      }
    });
    return flattened;
  };

  useEffect(() => {
    setGroupName(isEditMode ? initialGroupName : '');
    setSelectedParentGroupId(isEditMode ? initialParentGroupId : null);
  }, [show, isEditMode, initialGroupName, initialParentGroupId]);

  const groupOptions: GroupOption[] = flattenGroups(allGroups);
  groupOptions.unshift({ value: null, label: 'მთავარ ჯგუფად დამატება' });

  const selectedOption = groupOptions.find(option => option.value === selectedParentGroupId);

  const handleParentGroupChange = (selectedOption: SingleValue<{ value: number | null; label: string }>) => {
    setSelectedParentGroupId(selectedOption ? selectedOption.value : null);
  };

  const handleSave = () => {
    const groupData = {
      name: groupName,
      parentGroupId: selectedParentGroupId
    };

    const hasErrors = validateGroup(groupData);

    if (!hasErrors) {
      onSave(groupData as (GroupCreationModel | GroupEditionModel));
    }
  };

  return (
    <Modal show={show} onHide={handleClose} contentClassName="p-3" centered dialogClassName="modal-lg">
      <Modal.Header closeButton>
        <Modal.Title>{isEditMode ? 'ჯგუფის რედაქტირება' : 'ჯგუფის დამატება'}</Modal.Title>
      </Modal.Header>
      <Modal.Footer className="justify-content-start">
        <Button variant="success" onClick={handleSave}>შენახვა</Button>
        <Button variant="light" onClick={handleClose}>გაუქმება</Button>
      </Modal.Footer>
      <Modal.Body>
        <Form>
          <Form.Group as={Row}>
            <Form.Label className='text-end' column sm={3}>ჯგუფი:</Form.Label>
            <Col sm={9}>
              <Select
                className="mb-3"
                options={groupOptions}
                value={selectedOption}
                onChange={handleParentGroupChange}
                isClearable
              />
            </Col>
          </Form.Group>
          <Form.Group as={Row}>
            <Form.Label className='text-end' column sm={3}>დასახელება:</Form.Label>
            <Col sm={9}>
              <Form.Control
                isInvalid={!!groupValidationErrors.name}
                className="mb-3"
                type="text"
                value={groupName}
                onChange={e => setGroupName(e.target.value)}
              />
              <Form.Control.Feedback className="mb-3" type="invalid"> {groupValidationErrors.name} </Form.Control.Feedback>
            </Col>
          </Form.Group>
        </Form>
      </Modal.Body>
    </Modal>
  );
};

export default AddGroupModal;