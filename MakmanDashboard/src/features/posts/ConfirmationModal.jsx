import styled from 'styled-components';
import { Button } from '../../components';

const StyledConfirmDelete = styled.div`
  position: fixed;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background-color: white;
  border-radius: var(--border-radius-4);
  padding: 3.2rem 4rem;
  transition: all 0.5s;
  width: 30rem;
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  gap: 1.2rem;

  & p {
    color: var(--color-grey-500);
    margin-bottom: 1.2rem;
  }

  & div {
    display: flex;
    justify-content: flex-end;
    gap: 1.2rem;
  }
`;

const Overlay = styled.div`
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100vh;
  background-color: var(--grey-700);
  opacity: 0.8;
  z-index: 1000;
  transition: all 0.5s;
`;

export const ConfirmationModal = ({ disabled, onConfirm, onCloseModal }) => {
  return (
    <Overlay>
      <StyledConfirmDelete>
        <p>Are you sure you want to delete the post?</p>

        <div>
          <Button variation='danger' disabled={disabled} onClick={onConfirm}>
            Delete
          </Button>
          <Button
            variation='secondary'
            disabled={disabled}
            onClick={onCloseModal}
          >
            Cancel
          </Button>
        </div>
      </StyledConfirmDelete>
    </Overlay>
  );
};
