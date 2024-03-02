import React, { useState } from 'react';
import { FaPen, FaPlus, FaXmark } from 'react-icons/fa6';
import AddGroupModal from '../../Modals/GroupModals/AddGroupModal';
import styles from './GroupActions.module.css';
import { Group } from '../../Models/Group';
import { GroupCreationModel } from '../../Models/GroupCreationModel';
import { ApiService } from '../../Api/ApiService';
import ConfirmationModal from '../../Modals/HelperModals/ConfirmationModal';
import { GroupEditionModel } from '../../Models/GroupEditionModel';

interface GroupActionsProps {
  groups: Group[];
  selectedGroup: Group | null;
  onGroupsUpdated: () => void;
}

const GroupActions: React.FC<GroupActionsProps> = ({ groups, selectedGroup, onGroupsUpdated }) => {
  const [isAddGroupModalOpen, setIsAddGroupModalOpen] = useState(false);
  const [showConfirmationModal, setShowConfirmationModal] = useState(false);
  const [isEditMode, setIsEditMode] = useState(false);
  const [selectedParentGroup, setSelectedParentGroup] = useState<Group | null>(null);

  const findParentGroupId = (groups: Group[], childId: number): number | null => {
    for (const group of groups) {
      if (group.subgroups?.some((subgroup: Group) => subgroup.id === childId)) {
        return group.id;
      }
      const parentGroupId = findParentGroupId(group.subgroups || [], childId);
      if (parentGroupId !== null) return parentGroupId;
    }
    return null;
  };


  const handleAddGroup = () => {
    setIsAddGroupModalOpen(true);
  };

  const findParentGroup = (groups: Group[], childId: number): Group | null => {
    for (const group of groups) {
      if (group.subgroups?.some((subgroup: Group) => subgroup.id === childId)) {
        return group;
      }
      const parentGroup = findParentGroup(group.subgroups || [], childId);
      if (parentGroup) return parentGroup;
    }
    return null;
  };

  const handleEditGroup = () => {
    if (selectedGroup) {
      setIsAddGroupModalOpen(true);
      setIsEditMode(true);

      const parentGroup = findParentGroup(groups, selectedGroup.id);
      setSelectedParentGroup(parentGroup); // Now parentGroup is a Group object or null
    }
  };

  const handleDeleteGroup = async () => {
    if (selectedGroup) {
      setShowConfirmationModal(true);
    }
  };

  const handleSaveGroup = async (groupData: GroupCreationModel | GroupEditionModel) => {
    if (isEditMode && selectedGroup) {
      try {
        // Use the parentGroupId from the edited data, not the original selectedGroup
        const editionData: GroupEditionModel = {
          name: groupData.name,
          parentGroupId: groupData.parentGroupId
        };
        await ApiService.editGroup(selectedGroup.id, editionData);
      } catch (error) {
        console.error('Error updating group', error);
      }
    } else {
      try {
        await ApiService.createGroup(groupData as GroupCreationModel);
      } catch (error) {
        console.error('Error creating group', error);
      }
    }
    setIsAddGroupModalOpen(false);
    setIsEditMode(false);
    onGroupsUpdated();
  };

  const confirmDeletion = async () => {
    if (selectedGroup) {
      try {
        await ApiService.deleteGroup(selectedGroup.id);
        console.log("Group deleted:", selectedGroup);
        setShowConfirmationModal(false);
        onGroupsUpdated();
      } catch (error) {
        console.error('Error deleting product', error);
      }
    }
    setShowConfirmationModal(false);
  };

  const cancelDeletion = () => {
    setShowConfirmationModal(false);
  };

  return (
    <div className={styles.groupActionBtn}>
      <button className={styles.groupActionIcons} onClick={handleAddGroup}>
        <FaPlus />
      </button>
      <button className={styles.groupActionIcons} onClick={handleEditGroup}>
        <FaPen />
      </button>
      <button className={styles.groupActionIcons} onClick={handleDeleteGroup}>
        <FaXmark />
      </button>

      {isAddGroupModalOpen && (
        <AddGroupModal
          show={isAddGroupModalOpen}
          handleClose={() => { setIsAddGroupModalOpen(false); setIsEditMode(false); }}
          onSave={handleSaveGroup}
          allGroups={groups}
          isEditMode={isEditMode}
          initialGroupName={isEditMode && selectedGroup ? selectedGroup.name : ''}
          initialParentGroupId={selectedParentGroup ? selectedParentGroup.id : null}
        />
      )}

      <ConfirmationModal
        show={showConfirmationModal}
        productName={selectedGroup ? selectedGroup.name : ''}
        onConfirm={confirmDeletion}
        onCancel={cancelDeletion}
      />
    </div>
  );
};

export default GroupActions;