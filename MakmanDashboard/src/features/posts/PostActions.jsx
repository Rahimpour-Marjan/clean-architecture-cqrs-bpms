import styled from 'styled-components';
import deleteIcon from '../../assets/delete.svg';
import editIcon from '../../assets/edit.svg';
import { Button } from '../../components';

const PostActionStyled = styled.div`
  display: flex;
  align-self: start;
  gap: 1rem;
  margin: 1rem;
  margin-left: auto;

  button {
    background-color: transparent;
    border: none;
  }
`;

const Action = ({ onClick, src, alt }) => {
  return (
    <Button onClick={onClick}>
      <img src={src} alt={`${alt}-post`} />
    </Button>
  );
};

export const PostActions = ({ onEdit, onDelete }) => {
  return (
    <PostActionStyled>
      <Action onClick={onEdit} src={editIcon} alt='edit' />
      <Action onClick={onDelete} src={deleteIcon} alt='delete' />
    </PostActionStyled>
  );
};
