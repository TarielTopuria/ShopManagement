import { Button, Col, Form, InputGroup, Modal, Row } from "react-bootstrap";
import Select, { SingleValue } from "react-select";
import { Group } from "../../Models/Group";
import { useEffect, useState } from "react";
import { Country } from "../../Models/Country";
import { Product } from "../../Models/Product";
import { ProductCreationModel } from "../../Models/ProductCreationModel";
import { ApiService } from "../../Api/ApiService";
import useProductValidation from "../../Validations/Product/useProductValidation";
import useCountryValidation from "../../Validations/Country/useCountryValidation";

interface AddProductModalProps {
  show: boolean;
  handleClose: () => void;
  onSave: (newProduct: ProductCreationModel) => void;
  productForEdit?: Product;
  isEditMode: boolean;
  countries: Country[];
  groups: Group[];
}

const AddProductModal: React.FC<AddProductModalProps> = ({ show, handleClose, onSave, productForEdit, isEditMode, countries, groups }) => {
  const [productCode, setProductCode] = useState<string>('');
  const [productName, setProductName] = useState<string>('');
  const [productPrice, setProductPrice] = useState<number>(0);
  const [productStartDate, setProductStartDate] = useState<Date>(new Date());
  const [productEndDate, setProductEndDate] = useState<Date>(new Date());
  const [selectedGroup, setSelectedGroup] = useState<Group | null>(null);
  const [selectedCountry, setSelectedCountry] = useState<Country | null>(null);
  const [showAddCountryModal, setShowAddCountryModal] = useState<boolean>(false);
  const [newCountryName, setNewCountryName] = useState<string>('');
  const { validateProduct, validationErrors } = useProductValidation();
  const { validateCountry, countryValidationErrors } = useCountryValidation();

  useEffect(() => {
    if (productForEdit) {
      setProductCode(productForEdit.code);
      setProductName(productForEdit.name);
      setProductPrice(productForEdit.price);
      setProductStartDate(new Date(productForEdit.startDate));
      setProductEndDate(new Date(productForEdit.endDate));

      const foundGroup = findGroupById(productForEdit.groupId, groups);
      setSelectedGroup(foundGroup);

      const foundCountry = countries.find(c => c.id === productForEdit.countryId);
      setSelectedCountry(foundCountry || null);
    } else {
      setProductCode('');
      setProductName('');
      setProductPrice(0);
      setProductStartDate(new Date());
      setProductEndDate(new Date());
      setSelectedGroup(null);
      setSelectedCountry(null);
    }
  }, [productForEdit, groups, countries]);

  const formatDate = (date: Date): string => {
    return date.toISOString().split('T')[0];
  };

  const flattenGroups = (groups: Group[], prefix = ''): { value: number; label: string; isDisabled: boolean }[] => {
    return groups.reduce((acc: { value: number; label: string; isDisabled: boolean }[], group: Group) => {
      const subgroups = group.subgroups || [];
      const hasSubgroups = subgroups.length > 0;
      acc.push({ value: group.id, label: `${prefix}${group.name}`, isDisabled: hasSubgroups });
      if (hasSubgroups) {
        acc.push(...flattenGroups(subgroups, prefix + " "));
      }
      return acc;
    }, []);
  };

  const findGroupById = (id: number, groups: Group[]): Group | null => {
    for (const group of groups) {
      if (group.id === id) return group;
      if (group.subgroups) {
        const found = findGroupById(id, group.subgroups);
        if (found) return found;
      }
    }
    return null;
  };

  const handleGroupChange = (selectedOption: SingleValue<{ value: number; label: string }>) => {
    if (selectedOption) {
      const selectedGroup = findGroupById(selectedOption.value, groups);
      setSelectedGroup(selectedGroup);
    } else {
      setSelectedGroup(null);
    }
  };

  const handleCountryChange = (selectedOption: SingleValue<{ value: number; label: string }>) => {
    if (selectedOption) {
      if (selectedOption.value === -1) {
        setShowAddCountryModal(true);
      } else {
        const country = countries.find(c => c.id === selectedOption.value);
        setSelectedCountry(country || null);
      }
    } else {
      setSelectedCountry(null);
    }
  };

  const handleSave = () => {
    const newProduct = {
      code: productCode,
      name: productName,
      price: productPrice,
      startDate: productStartDate,
      endDate: productEndDate,
      countryId: selectedCountry ? selectedCountry.id : 0,
      groupId: selectedGroup ? selectedGroup.id : 0,
    };

    const hasErrors = validateProduct(newProduct);

    if (!hasErrors) {
      const newProduct = {
        code: productCode,
        name: productName,
        price: productPrice,
        startDate: productStartDate,
        endDate: productEndDate,
        countryId: selectedCountry ? selectedCountry.id : 0,
        groupId: selectedGroup ? selectedGroup.id : 0
      };

      onSave(newProduct);
    }
  };

  const addNewCountry = async () => {
    const newCountry = {
      name: newCountryName
    };

    const hasErrors = validateCountry(newCountry);

    if (!hasErrors) {
      try {
        const newCountry = await ApiService.createCountry({ name: newCountryName });
        countries.push(newCountry);
        setSelectedCountry(newCountry);
        setNewCountryName('');
        setShowAddCountryModal(false);
      } catch (error) {
        console.error('Error adding new country:', error);
      }
    }
  };

  if (!show) {
    return null;
  }

  const groupOptions = groups ? flattenGroups(groups) : [];
  const countryOptions = [{ value: -1, label: '<დამატება>' }, ...countries.map(country => ({ value: country.id, label: country.name }))];

  return (
    <>
      <Modal show={show} onHide={handleClose} contentClassName= "p-3" centered dialogClassName="modal-lg">
        <Modal.Header closeButton>
          <Modal.Title>{isEditMode ? 'პროდუქტის რედაქტირება' : 'პროდუქტის დამატება'}</Modal.Title>
        </Modal.Header>
        <Modal.Footer className="justify-content-start" >
          <Button variant="success" onClick={handleSave}>შენახვა</Button>
          <Button variant="light" onClick={handleClose}>გაუქმება</Button>
        </Modal.Footer>
        <Modal.Body>
          <Form>
            <Form.Group as={Row}>
              <Form.Label className='text-end' column sm={3}>კოდი:</Form.Label>
              <Col sm={9}>
                <Form.Control isInvalid={!!validationErrors.code} className="mb-3" type="text" value={productCode} onChange={e => setProductCode(e.target.value)} />
                <Form.Control.Feedback className="mb-3" type="invalid"> {validationErrors.code} </Form.Control.Feedback>
              </Col>
            </Form.Group>

            <Form.Group as={Row}>
              <Form.Label className='text-end' column sm={3}>ჯგუფი:</Form.Label>
              <Col sm={9}>
                <Select
                  className="mb-3"
                  options={groupOptions}
                  value={selectedGroup ? { value: selectedGroup.id, label: selectedGroup.name } : null}
                  onChange={handleGroupChange}
                  isClearable
                  placeholder="აირჩიეთ ჯგუფი"
                />
                <Form.Text className="text-danger">{validationErrors.groupId}</Form.Text>
              </Col>
            </Form.Group>

            <Form.Group as={Row}>
              <Form.Label className={!validationErrors.groupId ? "text-end mb-3" : "text-end my-3"} column sm={3}>დასახელება:</Form.Label>
              <Col sm={9}>
                <Form.Control isInvalid={!!validationErrors.name} className={!validationErrors.groupId ? "mb-3" : "my-3"} type="text" value={productName} onChange={e => setProductName(e.target.value)} />
                <Form.Control.Feedback className="mb-3" type="invalid"> {validationErrors.name} </Form.Control.Feedback>
              </Col>
            </Form.Group>

            <Form.Group as={Row}>
              <Form.Label className='text-end' column sm={3}>ფასი:</Form.Label>
              <Col sm={9}>
                <Form.Control isInvalid={!!validationErrors.price} className="mb-3" type="number" value={productPrice} onChange={e => setProductPrice(Number(e.target.value))} />
                <Form.Control.Feedback className="mb-3" type="invalid"> {validationErrors.price} </Form.Control.Feedback>
              </Col>
            </Form.Group>

            <Form.Group as={Row}>
              <Form.Label className='text-end' column sm={3}>ქვეყანა:</Form.Label>
              <Col sm={9}>
                <Select
                  className="mb-3"
                  options={countryOptions}
                  // value={{ label: selectedCountry?.name || null, value: selectedCountry?.id || 0 }}
                  value={selectedCountry ? { value: selectedCountry.id, label: selectedCountry.name } : null}
                  onChange={handleCountryChange}
                  placeholder="აირჩიეთ ქვეყანა"
                />
                <Form.Text className="text-danger">{validationErrors.countryId}</Form.Text>
              </Col>
            </Form.Group>

            <Form.Group as={Row}>
              <Form.Label className={!validationErrors.startDate ? "text-end mb-3" : "text-end my-3"} column sm={2}>თარიღიდან:</Form.Label>
              <Col sm={4}>
                <Form.Control isInvalid={!!validationErrors.startDate} className={!validationErrors.startDate ? "text-end mb-3" : "text-end my-3"} type="date" value={formatDate(productStartDate)} onChange={e => setProductStartDate(new Date(e.target.value))} />
                <Form.Control.Feedback className="mb-3" type="invalid"> {validationErrors.startDate} </Form.Control.Feedback>
              </Col>
              <Form.Label className={!validationErrors.startDate ? "text-end mb-3" : "text-end my-3"} column sm={2}>თარიღამდე:</Form.Label>
              <Col sm={4}>
                <Form.Control isInvalid={!!validationErrors.startDate} className={!validationErrors.startDate ? "text-end mb-3" : "text-end my-3"} type="date" value={formatDate(productEndDate)} onChange={e => setProductEndDate(new Date(e.target.value))} />
                <Form.Control.Feedback className="mb-3" type="invalid"> {validationErrors.startDate} </Form.Control.Feedback>
              </Col>
            </Form.Group>

          </Form>
        </Modal.Body>
      </Modal>

      <Modal show={showAddCountryModal} onHide={() => setShowAddCountryModal(false)}>
        <Modal.Header closeButton>
          <Modal.Title>ახალი ქვეყნის დამატება</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <InputGroup>
            <Form.Control
              isInvalid={!!countryValidationErrors.name}
              type="text"
              placeholder="მიუთითეთ ქვეყნის დასახელება"
              value={newCountryName}
              onChange={(e) => setNewCountryName(e.target.value)}
            />
            <Form.Control.Feedback className="mb-3" type="invalid">{countryValidationErrors.name}</Form.Control.Feedback>
            <Button variant="outline-secondary" onClick={addNewCountry}>დამატება</Button>
          </InputGroup>
        </Modal.Body>
      </Modal>
    </>
  );
};


export default AddProductModal;