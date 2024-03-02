import React from 'react';
import { Modal, Button } from 'react-bootstrap';

interface ConfirmationModalProps {
  show: boolean;
  productName: string;
  onConfirm: () => void;
  onCancel: () => void;
}

const ConfirmationModal: React.FC<ConfirmationModalProps> = ({ show, productName, onConfirm, onCancel }) => {
  return (
    <Modal show={show} onHide={onCancel} centered>
      <Modal.Header closeButton>
        <Modal.Title>დაადასტურეთ წაშლა</Modal.Title>
      </Modal.Header>
      <Modal.Body>
        {`დარწმუნებული ხართ, რომ გსურთ წაშალოთ "${productName}"?`}
      </Modal.Body>
      <Modal.Footer>
        <Button variant="secondary" onClick={onCancel}>
          არა
        </Button>
        <Button variant="danger" onClick={onConfirm}>
          დიახ
        </Button>
      </Modal.Footer>
    </Modal>
  );
};

export default ConfirmationModal;
