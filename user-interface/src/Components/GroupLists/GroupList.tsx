import React, { useState, useEffect } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faCaretDown, faCaretRight } from '@fortawesome/free-solid-svg-icons';
import styles from './GroupList.module.css';
import { Group } from '../../Models/Group';

interface GroupListProps {
  groups: Group[];
  onGroupSelect?: (group: Group) => void;
}

const GroupList: React.FC<GroupListProps> = ({ groups, onGroupSelect }) => {
  const [openGroups, setOpenGroups] = useState<Set<number>>(new Set());
  const [selectedGroupId, setSelectedGroupId] = useState<number | null>(null);

  const toggleGroup = (id: number) => {
    setOpenGroups(prev => {
      const newOpenGroups = new Set(prev);
      if (newOpenGroups.has(id)) {
        newOpenGroups.delete(id);
      } else {
        newOpenGroups.add(id);
      }
      return newOpenGroups;
    });
  };

  const handleGroupClick = (group: Group, event: React.MouseEvent) => {
    event.stopPropagation();
    toggleGroup(group.id);
    setSelectedGroupId(group.id);
    if (onGroupSelect) {
      onGroupSelect(group);
    }
  };

  const renderGroups = (groups: Group[], level = 0) => {
    return (
      <ul className={level === 0 ? styles.groupListContainer : ''}>
        {groups.map(group => (
          <li key={group.id} className={styles.groupItem}>
            <div
              className={selectedGroupId === group.id ? styles.selectedGroup : ''}
              onClick={(event) => handleGroupClick(group, event)}>
              {group.subgroups && group.subgroups.length > 0 && (
                <FontAwesomeIcon icon={openGroups.has(group.id) ? faCaretDown : faCaretRight} />)} {group.name} </div>
            {group.subgroups && openGroups.has(group.id) && (
              <div className={styles.subGroup}>
                {renderGroups(group.subgroups, level + 1)}
              </div>
            )}
          </li>
        ))}
      </ul>
    );
  };

  return <div>{renderGroups(groups)}</div>;
};

export default GroupList;
